import React, { useEffect, useState } from 'react';
import api from '../services/api';
import SearchByNotes from './SearchByNotes';

export default function PerfumeList(){
  const [perfumes, setPerfumes] = useState([]);

  useEffect(()=>{ api.get('/perfumes').then(r=>setPerfumes(r.data)); }, []);

  return (
    <div>
      <h2>Perfumes</h2>
      <SearchByNotes onResults={setPerfumes} />
      {perfumes.map(p=> (
        <div className="perfume" key={p.id}>
          <b>{p.name}</b> - {p.brand} - ${p.price}
        </div>
      ))}
    </div>
  )
}
