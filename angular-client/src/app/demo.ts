import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DemoEntity } from '../models/demo-entity';

@Injectable({
  providedIn: 'root'
})
export class Demo {
  private apiUrl = 'http://localhost:5248/api/DemoEntities';

  constructor(private http: HttpClient) {}

  getAll(): Observable<DemoEntity[]> {
    return this.http.get<DemoEntity[]>(this.apiUrl);
  }

  getById(id: number): Observable<DemoEntity> {
    return this.http.get<DemoEntity>(`${this.apiUrl}/${id}`);
  }

  create(entity: Partial<DemoEntity>): Observable<DemoEntity> {
    return this.http.post<DemoEntity>(this.apiUrl, entity);
  }

  update(id: number, entity: Partial<DemoEntity>): Observable<DemoEntity> {
    return this.http.put<DemoEntity>(`${this.apiUrl}/${id}`, entity);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
