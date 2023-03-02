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
        <div className="block" style={{minHeight:"calc(100vh - 100px - 100px)"}}>
           <Routes>
            {user.isAuth==true && user.User.role=='User' && authRoutes.map(({path,element})=>
            <Route key={path} path={path} element={element} exact/>)}
               {user.isAuth==true && user.User.role=='Admin' && authRoutes.map(({path,element})=>
                   <Route key={path} path={path} element={element} exact/>)}

               {!user.isAuth && pubRoutes.map(({path,element})=>
            <Route key={path} path={path} element={element} exact/>)}
            </Routes> 
        </div>
      );
            
})
 
export default AppRouter;