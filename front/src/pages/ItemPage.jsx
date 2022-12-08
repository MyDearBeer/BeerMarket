import { observer } from 'mobx-react-lite'
import React, { useEffect } from 'react'
import { useState } from 'react'
import { useContext } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { Context } from '..'
import { fetchFactoryById, fetchItemsById, fetchTypeById } from '../http/ItemAPI'
import { BASKETROUTE, REGROUTE, variables } from '../utils/consts'

import './ItemPage.css'



const ItemPage = () => {
  const[item,setItems]=useState({itemInfo:[]})
  const[type,setType]=useState({name:''})
  const[factory,setFactory]=useState({name:''})
  //console.log(item.info)
 // const item=   {id:1,name:"Львівське 1715",price:20,rating:5,img:"./beerImg/lviv1715.png"}
  const navigate=useNavigate()
  const {id}=useParams()
  const {product}=useContext(Context)
  const{user} = useContext(Context)
  useEffect(()=>{
    fetchItemsById(id).then(data=>setItems(data))
    //fetchTypeById(item.typeId).then(data=>product.setSelectedType(data))
    
},[])

useEffect(()=>{
fetchTypeById(item.typeId).then(data=>setType(data))
fetchFactoryById(item.factoryId).then(data=>setFactory(data))
},[item.typeId,item.factoryId])
 //product.type.id=item.typeId

 //console.log(product.selectedType.name)

//const firstItem=item.info[0]

console.log(type)
    return (
        <div className='itempage'>
          <div className='upside'>
           <div>
<img src={variables.PHOTO_URL+item.img}></img>
</div>
           
            <div className='stats'>
              <div> 
                {/* <h1>{item.name}</h1> */}
                <div style={{marginTop:"50px"}}> 
                <p>Тип товару: {type.name}</p>
                <p>Виробник: {factory.name}</p>
                {item.itemInfo.map(info=>
    <p  key={info.id}>{info.title}:{info.value}</p> )}
                <p>Ціна: {item.price} грн за 1 одиницю товару</p>
                <button onClick={()=>user.isAuth? navigate(BASKETROUTE): navigate(REGROUTE)} style={{marginTop:"30px"}}>Додати у кошик</button>
                </div> 
                </div>
                
              </div>
         </div>
              <div className='itemdescription'>{item.description}</div>
        </div>
        
      );
}
 
export default ItemPage;