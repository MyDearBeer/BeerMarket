import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { BrowserRouter, Routes, Route, Redirect,useNavigate } from 'react-router-dom';
import { Context } from '..';
import { authRoutes, pubRoutes } from '../Routes';
import { SHOPROUTE } from '../utils/consts';

const AppRouter = observer(() => {
    const{user}=useContext(Context)
 console.log(user)
    return (
        <div>
           <Routes>
            {user.isAuth==true?  authRoutes.map(({path,element})=>
            <Route key={path} path={path} element={element} exact/>)
           
              :
             
              pubRoutes.map(({path,element})=>
            <Route key={path} path={path} element={element} exact/>)}
            </Routes> 
        </div>
      );
            
})
 
export default AppRouter;