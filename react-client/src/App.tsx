import './App.css';
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useForm } from 'react-hook-form';

const apiUrl = 'http://localhost:5265/api/DemoEntities';
type DemoEntity = {
  id: number;
  name: string;
};
type FormData = { name: string };

function App() {
  const { register, handleSubmit, reset, setValue } = useForm<FormData>();
  const [entities, setEntities] = useState<DemoEntity[]>([]);
  const [editingId, setEditingId] = useState<number | null>(null);

  const loadEntities = async () => {
    const res = await axios.get(apiUrl);
    setEntities(res.data);
  };

  useEffect(() => {
    loadEntities();
  }, []);

  const onSubmit = async (data: { name: string }) => {
    if (editingId) {
      await axios.put(`${apiUrl}/${editingId}`, { ...data, id: editingId });
    } else {
      await axios.post(apiUrl, data);
    }
    reset();
    setEditingId(null);
    loadEntities();
  };

  const editEntity = (entity: { id: number; name: string }) => {
    setEditingId(entity.id);
    setValue('name', entity.name);
  };

  const deleteEntity = async (id: number) => {
    if (window.confirm('Delete this item?')) {
      await axios.delete(`${apiUrl}/${id}`);
      loadEntities();
    }
  };

  const cancelEdit = () => {
    setEditingId(null);
    reset();
  };

  return (
    <div style={{ maxWidth: 400, margin: '2rem auto' }}>
      <form onSubmit={handleSubmit(onSubmit)} style={{ marginBottom: 20 }}>
        <input
          {...register('name', { required: true })}
          placeholder="Name"
          style={{ marginRight: 8 }}
        />
        <button type="submit">{editingId ? 'Update' : 'Create'}</button>
        {editingId && (
          <button type="button" onClick={cancelEdit} style={{ marginLeft: 8 }}>
            Cancel
          </button>
        )}
      </form>

      <ul>
        {entities.map((entity) => (
          <li key={entity.id} style={{ marginBottom: 8 }}>
            {entity.name}
            <button onClick={() => editEntity(entity)} style={{ marginLeft: 8 }}>
              Edit
            </button>
            <button onClick={() => deleteEntity(entity.id)} style={{ marginLeft: 4 }}>
              Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}



export default App;
