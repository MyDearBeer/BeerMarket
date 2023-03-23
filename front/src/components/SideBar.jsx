import { observer } from 'mobx-react-lite';
import React, { useContext } from 'react'
import { useEffect } from 'react';
import { Context } from '..';
import { fetchFactories, fetchTypes } from '../http/ItemAPI';
import ItemMarket from '../store/ItemMarket';
import { variables } from '../utils/consts';

const SideBar = observer( ()=> {
    const {product}=useContext(Context)
   console.log(product)
    useEffect(()=>{
        fetchTypes().then(data=>product.setType(data.types))
        product.setSelectedType({})
    },[])
    useEffect(()=>{
        fetchFactories().then(data=>product.setFactory(data.factories))
    },[])
    return (
        <div className='bar'>
            <h2>Типи товарів</h2>
        <div className='sidebar'>

{product.type.map(type=>
    <a style={type.id===product.selectedType.id
        ? {backgroundColor:"white"}: {backgroundColor:""}}
       onClick={()=>{type.id===product.selectedType.id
           ? product.setSelectedType({}): product.setSelectedType(type)}}
       key={type.id}>{type.name}</a> )}
          </div>
            <h2 className="factoryH">Фірми</h2>
            <div className='sidebar'>
{product.factory.map(factory=>
    <a style={factory.id===product.selectedFactory.id
        ? {backgroundColor:"white"}: {backgroundColor:""}}
       onClick={()=>factory.id===product.selectedFactory.id
           ? product.setSelectedFactory({}):product.setSelectedFactory(factory)}
       key={factory.id}>{factory.name}</a> )}
        </div>
        </div>
      );
})
 
export default SideBar;