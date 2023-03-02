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
  const[item,setItems]=useState({type:{},factory:{},info:[]})
  const[type,setType]=useState({name:''})
  const[factory,setFactory]=useState({name:''})
  //console.log(item.info)
 // const item=   {id:1,name:"Львівське 1715",price:20,rating:5,img:"./beerImg/lviv1715.png"}
  const navigate=useNavigate()
  const {id}=useParams()
  const {product}=useContext(Context)
  const{user} = useContext(Context)
  useEffect(()=>{
    fetchItemsById(id).then(data=>{

        setItems(data)
        console.log(data)
    })
    //fetchTypeById(item.typeId).then(data=>product.setSelectedType(data))

},[])



 //product.type.id=item.typeId

 console.log(item)

//const firstItem=item.info[0]


    return (

          <div className='upside'>

<img src={variables.PHOTO_URL+item.img}></img>

           
            <div className='stats'>

                {/* <h1>{item.name}</h1> */}

                    <p>{item.name}</p>
                <p>{item.type.name}, {item.factory.name}</p>
                <div className='infodiv'>
                {item.info.map(info=>
    <h3  key={info.id}>{info.title}: {info.value} </h3> )}
                </div>
                <p>Ціна: {item.price} грн за 1 одиницю товару</p>
                <div className='itemdescription'>
                    <p>{item.description}</p>
                </div>
                <div className='basketBtn'>
                    <button onClick={()=>user.isAuth? navigate(BASKETROUTE): navigate(REGROUTE)} style={{marginTop:"30px"}}>Додати у кошик</button>
                </div>
                </div>


         </div>


        
      );
}
 
export default ItemPage;