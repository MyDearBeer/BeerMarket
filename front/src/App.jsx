import React, {useContext, useEffect, useState} from 'react'
import './App.css';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
import AppRouter from './components/AppRouter';
import NavBar from './components/NavBar';
import Footer from "./components/Footer";
import {observer} from "mobx-react-lite";
import {Context} from "./index";
import {check} from "./http/UserAPI";
import {Spinner} from "react-bootstrap";

const App= observer(()=> {
    const {user} = useContext(Context)
    const [loading, setLoading] = useState(true)

    useEffect(()=>{
        check().then(data=>{
            console.log(data)
            user.setUser(data)
            user.setisAuth(true)

        }).finally(()=>setLoading(false))
    },[])
    console.log(localStorage)
    if(loading){
        return <Spinner animation={"grow"}/>
    }

  return (
    <div className="App" style={{minHeight:"90vh"}}>
      <BrowserRouter>
      <NavBar/>
    <AppRouter/>
          <Footer/>
     </BrowserRouter>
    </div>
  );
})

export default App;
