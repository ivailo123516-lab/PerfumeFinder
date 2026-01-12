import api from './api';

export async function login(username, password){
  const res = await api.post('/auth/login', { username, password });
  if(res.data.token) localStorage.setItem('token', res.data.token);
  return res.data;
}

export function getAuthHeader(){
  const token = localStorage.getItem('token');
  return token ? { Authorization: `Bearer ${token}` } : {};
}
