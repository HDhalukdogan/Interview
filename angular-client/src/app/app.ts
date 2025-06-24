import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { Demo } from './demo';
import { DemoEntity } from '../models/demo-entity';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,ReactiveFormsModule,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected title = 'angular-client';
  demoEntities: DemoEntity[] = [];
  form: FormGroup;
  editingId: number | null = null;
  loading = false;

  constructor(private demoEntityService: Demo, private fb: FormBuilder) {
    this.form = this.fb.group({
      id: [null],
      name: ['', Validators.required]
    });
  }

  ngOnInit() {
    this.loadEntities();
  }

  loadEntities() {
    this.loading = true;
    this.demoEntityService.getAll().subscribe({
      next: data => {
        this.demoEntities = data;
        this.loading = false;
      },
      error: () => this.loading = false
    });
  }

  submit() {
    if (this.form.invalid) return;

    const entity = this.form.value;
    if (this.editingId) {
      this.demoEntityService.update(this.editingId, entity).subscribe(() => {
        this.loadEntities();
        this.cancel();
      });
    } else {
      this.demoEntityService.create(entity).subscribe(() => {
        this.loadEntities();
        this.form.reset();
      });
    }
  }

  edit(entity: DemoEntity) {
    this.editingId = entity.id;
    this.form.patchValue(entity);
  }

  cancel() {
    this.editingId = null;
    this.form.reset();
  }

  remove(id: number) {
    if (confirm('Delete this item?')) {
      this.demoEntityService.delete(id).subscribe(() => this.loadEntities());
    }
  }
}
