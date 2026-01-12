import React, { useEffect, useState } from 'react';
import api from '../services/api';

export default function SearchByNotes({ onResults }){
  const [notes, setNotes] = useState([]);
  const [selected, setSelected] = useState([]);

  useEffect(()=>{ api.get('/notes').then(r=>setNotes(r.data)); }, []);

  function toggle(id){
    setSelected(s => s.includes(id) ? s.filter(x=>x!==id) : [...s, id]);
  }

  async function search(){
    const res = await api.post('/perfumes/recommend', { noteIds: selected });
    onResults(res.data);
  }

  return (
    <div>
      <h3>Search by notes</h3>
      {notes.map(n=> (
        <label key={n.id} style={{display:'inline-block', marginRight:8}}>
          <input type="checkbox" onChange={()=>toggle(n.id)} /> {n.name}
        </label>
      ))}
      <div><button onClick={search}>Search</button></div>
    </div>
  )
}
