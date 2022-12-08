import React, { useContext } from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Context } from '..';
import { Button, NavLink } from 'react-bootstrap';
import {observer} from "mobx-react-lite"
import { ADMINROUTE, BASKETROUTE, REGROUTE, SHOPROUTE } from '../utils/consts';
import './Navbar.css'
import { useNavigate } from 'react-router-dom';


const NavBar =observer (() => {
    const {user}=useContext(Context)
    const navigate=useNavigate()
    return (
       
      <div className='navbar'>
<h1 style={{cursor:"pointer", paddingLeft:"10px"}} onClick={()=>navigate(SHOPROUTE)}>BeerMarket</h1>
<div className='navbtns'>
{user.isAuth ?
             <div className="admin">
           <button onClick={()=>{
            navigate(REGROUTE)
            user.setisAuth(false)}} >Вийти</button>
           <button onClick={()=>{navigate(ADMINROUTE)
          console.log(user)}} >Admin</button>
           <button onClick={()=>navigate(BASKETROUTE)} >Кошик</button>
           </div >
        : 
        <div >
        <button  onClick={()=>
          
          navigate(REGROUTE)}>Авторизація</button>
        </div>}
</div>
      </div>

       
      );
})
 
export default NavBar;