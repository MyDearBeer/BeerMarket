import React, { useContext } from 'react'
import Container from 'react-bootstrap/Container';
import Card from 'react-bootstrap/Card';
import { Form, Button } from 'react-bootstrap';
import { LOGINROUTE, REGROUTE, SHOPROUTE } from '../utils/consts';
import {useLocation, useNavigate, useNavigation } from 'react-router-dom';
import './Auth.css'
import { Context } from '..';

const Autorisation = () => {
  const navigate=useNavigate()
const location=useLocation()
const {user}=useContext(Context)
const isLogin =location.pathname==LOGINROUTE

    return (
        <div>
            <div className="authbox" style={{height:window.innerHeight-100}}>
                <div className='auth'>
                 <h2 >{isLogin ? "Авторизація" :"Регістрація"}</h2>
                <form className="forma">
                <input  type="email" placeholder="Enter email" /><br/>
                <input  type="password" placeholder="Password" />
                <div style={{display:"flex" ,justifyContent:"space-between"}}>
                <button type='submit' onClick={(e)=>{
              
                   user.setisAuth(true)
                 console.log(user)
                  navigate(SHOPROUTE)

                 }}>{isLogin ? "Вхід":"Регістрація"}</button>
                {isLogin ?
                <a href={REGROUTE}>Регістрація</a>
               :<a href={LOGINROUTE}>Авторизація</a>}
                </div>
                </form>
                </div>
            </div>
        </div>
      );
}
 
export default Autorisation;