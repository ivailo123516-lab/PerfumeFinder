import React from 'react';
import PerfumeList from './components/PerfumeList';
import PerfumeDetails from './components/PerfumeDetails';
import Login from './components/Login';
import Register from './components/Register';

export default function App(){
  return (
    <div className="app">
      <div className="header"><img src="/ivi-logo.svg" width={48} alt="logo"/><h1>PerfumeFinder</h1></div>
      <Login />
      <Register />
      <PerfumeList />
      <PerfumeDetails />
    </div>
  )
}
