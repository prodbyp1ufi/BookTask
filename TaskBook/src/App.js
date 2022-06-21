import React, { useState } from 'react';
import './App.css';
import BookList from './components/booksList';
import Login from './components/login';

export default  function App() {
  const [auth, setAuth] = useState(localStorage.getItem('testTaskBookToken') !== null)

  return (
    <div className="App">
      {
        auth  ? <BookList setAuth={setAuth}/> : <Login setAuth={setAuth}/>
      }
    </div>
  );
}