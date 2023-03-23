import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { BrowserRouter, Routes, Route, Redirect,useNavigate } from 'react-router-dom';
import { Context } from '..';
import {authAdminRoutes, authRoutes, pubRoutes} from '../Routes';
import { SHOPROUTE } from '../utils/consts';

const AppRouter = observer(() => {
    const{user}=useContext(Context)
 console.log(user)
    return (
        <div className="block" >
           <Routes>
            {user.isAuth==true && user.User.role=='User' && authRoutes.map(({path,element})=>
            <Route key={path} path={path} element={element} exact/>)}
               {user.isAuth==true && user.User.role=='Admin' && authAdminRoutes.map(({path,element})=>
                   <Route key={path} path={path} element={element} exact/>)}

               {!user.isAuth && pubRoutes.map(({path,element})=>
            <Route key={path} path={path} element={element} exact/>)}
            </Routes> 
        </div>
      );
            
})
 
export default AppRouter;