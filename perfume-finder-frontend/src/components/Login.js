import React, { useState } from 'react';
import { login } from '../services/auth';

export default function Login(){
  const [u, setU] = useState('');
  const [p, setP] = useState('');
  async function submit(e){
    e.preventDefault();
    try{
      await login(u,p);
      alert('Logged in');
    }catch(err){ alert('Login failed'); }
  }
  return (
    <form onSubmit={submit} style={{marginBottom:12}}>
      <input placeholder="username" value={u} onChange={e=>setU(e.target.value)} />
      <input placeholder="password" type="password" value={p} onChange={e=>setP(e.target.value)} />
      <button type="submit">Login</button>
    </form>
  )
}
