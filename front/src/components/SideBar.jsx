import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { useEffect } from 'react';
import { Context } from '..';
import { fetchFactories, fetchTypes } from '../http/ItemAPI';
import ItemMarket from '../store/ItemMarket';
import { variables } from '../utils/consts';

const SideBar = observer( ()=> {
    const {product}=useContext(Context)
   
    useEffect(()=>{
        fetchTypes().then(data=>product.setType(data))
        product.setSelectedType({})
    },[])
    useEffect(()=>{
        fetchFactories().then(data=>product.setFactory(data))
    },[])
    return (
        <div className='bar'>
        <div className='sidebar'>
            <h2>Типи товарів</h2>
{product.type.map(type=>
    <a style={type.id===product.selectedType.id ? {backgroundColor:"green"}: {backgroundColor:"white"}} onClick={()=>{type.id===product.selectedType.id ? product.setSelectedType({}): product.setSelectedType(type)}} key={type.id}>{type.name}</a> )}
          </div>
            <div style={{marginTop:"20px"}} className='sidebar'>
            <h2>Фірми</h2>
{product.factory.map(factory=>
    <a style={factory.id===product.selectedFactory.id ? {backgroundColor:"green"}: {backgroundColor:"white"}} onClick={()=>product.setSelectedFactory(factory)} key={factory.id}>{factory.name}</a> )}
        </div>
        </div>
      );
})
 
export default SideBar;