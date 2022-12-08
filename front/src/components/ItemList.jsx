import { observer } from 'mobx-react-lite';
import React, { useContext, useEffect } from 'react'
import { useNavigate, useNavigation } from 'react-router-dom';
import { Context } from '..';
import { fetchItems } from '../http/ItemAPI';
import { ITEMROUTE, variables } from '../utils/consts';

const ItemList = observer(() => {
    const {product}=useContext(Context)
    const navigate=useNavigate()
    useEffect(()=>{
        fetchItems(product.selectedType.id,product.selectedFactory.id,null,null).then(data=>{
            //product.setItem(data)
        console.log(data)
    product.setTotalCount(data.length)})
    },[product.selectedType.id,product.selectedFactory.id])
useEffect(()=>{
    fetchItems(product.selectedType.id,product.selectedFactory.id,product.page,product.limit).then(data=>{
        product.setItem(data)
        //product.setTotalCount(data.length)
    })
},[product.page,product.selectedType,product.selectedFactory])

    return (
        <div className='itemlist'>


{product.item.map(item=>
    <div style={{cursor:"pointer"}} key={item.id} onClick={()=>navigate(ITEMROUTE+'/'+item.id)}>
         <img src={variables.PHOTO_URL+ item.img}></img>
        <p style={{color:"gray"}}>{item.name}</p>
        <p>Ціна за 1 од.: {item.price} грн</p>
        <p>Рейтинг: {item.rating}</p>
        </div> )}
          
        </div>
   
      );
})
 
export default ItemList;