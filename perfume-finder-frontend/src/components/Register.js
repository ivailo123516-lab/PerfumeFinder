import React, { useState } from 'react';
import api from '../services/api';

export default function Register(){
  const [u, setU] = useState('');
  const [e, setE] = useState('');
  const [p, setP] = useState('');
  async function submit(e2){
    e2.preventDefault();
    try{
      await api.post('/auth/register', { username: u, email: e, password: p });
      alert('Registered');
    }catch(err){ alert('Register failed'); }
  }
  return (
    <form onSubmit={submit} style={{marginBottom:12}}>
      <input placeholder="username" value={u} onChange={e=>setU(e.target.value)} />
      <input placeholder="email" value={e} onChange={ev=>setE(ev.target.value)} />
      <input placeholder="password" type="password" value={p} onChange={ev=>setP(ev.target.value)} />
      <button type="submit">Register</button>
    </form>
  )
}
