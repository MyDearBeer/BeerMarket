import React, {useContext, useState} from 'react'
import Container from 'react-bootstrap/Container';
import Card from 'react-bootstrap/Card';
import { Form, Button } from 'react-bootstrap';
import { LOGINROUTE, REGROUTE, SHOPROUTE } from '../utils/consts';
import {useLocation, useNavigate, useNavigation } from 'react-router-dom';
import './Auth.css'
import { Context } from '..';
import {login, registration} from "../http/UserAPI";
import Warning from "../components/Warning";
import {observer} from "mobx-react-lite";

const Autorisation = observer(() => {
  const navigate=useNavigate()
const location=useLocation()
const {user}=useContext(Context)
const isLogin =location.pathname==LOGINROUTE
const [email,setEmail] = useState('')
const [password,setPassword] = useState('')
const[errDivAuth,setErrDivAuth] = useState(false)
const click = async () => {
      let data;
      try{
    if (email != '' && password != '') {
        if (isLogin) {
            data = await login(email, password)
            console.log(data)
        } else {
            data = await registration(email, password)
            console.log(data)
        }
        user.setUser(data)
        console.log(user)
        user.setisAuth(true)
        navigate(SHOPROUTE)

    }
    }catch (e){
          console.log(e)
setErrDivAuth(true)
      }
}

    return (
        <div>
            <div className="authbox" style={{height:window.innerHeight-100}}>
                <div className='auth'>
                 <h2 style={{marginTop:"10px"}}>{isLogin ? "Авторизація" :"Реєстрація"}</h2>
                <form className="forma">
                <input  style={!email? {border:"2px solid red"}: {borderColor:"blue"}}
                        type="email"
                        placeholder="Enter email"
                        value={email}
                        onChange={e=> setEmail(e.target.value)}
                /><br/>
                <input  style={!password? {border:"2px solid red"}: {borderColor:"blue"}}
                        type="password"
                        placeholder="Password"
                        value={password}
                        onChange={e=> setPassword(e.target.value)}
                />
                <div style={{display:"flex" ,justifyContent:"space-between"}}>
                <button type='submit' onClick={(e)=>{
              e.preventDefault()
                click()

                 // navigate(SHOPROUTE)

                 }}>{isLogin ? "Вхід":"Регістрація"}</button>
                {isLogin ?
                <a href={REGROUTE}>Регістрація</a>
               :<a href={LOGINROUTE}>Авторизація</a>}
                </div>
                    {errDivAuth &&
                        <Warning>{isLogin? "Невірний логін чи пароль":"Даний e-mail зайнятий"}</Warning>}
                </form>
                </div>
            </div>
        </div>
      );
})
 
export default Autorisation;