import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { useEffect } from 'react';
import { Context } from '..';
import { fetchTypes } from '../http/ItemAPI';
import ItemMarket from '../store/ItemMarket';
import { variables } from '../utils/consts';

const SideBar = observer( ()=> {
    const {typeitem}=useContext(Context)
    useEffect(()=>{
        fetchTypes().then(data=>typeitem.setType(data))
    },[])
    return (
        <div className='upbar'>
{typeitem.type.map(type=>
    <a style={type.id===typeitem.selectedType.id ? {backgroundColor:"green"}: {backgroundColor:"white"}} onClick={()=>typeitem.setSelectedType(type)} key={type.id}>{type.name}</a> )}
            {/* {typeitem.type.map(type=>
            
            <img src={variables.PHOTO_URL + type.img}></img>)} */}
        </div>
      );
})
 
export default SideBar;