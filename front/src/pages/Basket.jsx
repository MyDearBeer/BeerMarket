import React, {useContext, useEffect, useState} from 'react'
import  './Basket.css'
import {Context} from "../index";
import {observer} from "mobx-react-lite";
import {useLocation, useNavigate} from "react-router-dom";
import {fetchBasketItem} from "../http/ItemAPI";
import {BASKETROUTE, LOGINROUTE, variables} from "../utils/consts";
import Counter from "../components/tools/Counter";
import {forEach} from "react-bootstrap/ElementChildren";

const Basket = observer(()=>{
   const {product} = useContext(Context)
    const navigate = useNavigate()
    const location=useLocation()


    useEffect(()=>{
        fetchBasketItem().then(data=>{
            console.log()
            product.setBasketItem(data.basketProducts)
            product.setSumPrice(0)
            for (let i = 0; i < data.basketProducts.length; i++) {
                product.setSumPrice(product.sumPrice + data.basketProducts[i].product.price)
            }
            if(location.pathname!=BASKETROUTE)
                product.setSumPrice(0)
        })
    },[])



    return (
        <div className='basket'>
            {product.basketItem.map(item=>
                <div className='basketitem'>
                    <div className='basketleft'>
                        <img src={variables.PHOTO_URL+ item.product.img}></img>
                        <p>{item.product.name}</p>
                    </div>

                        {/*<div className='counter'>*/}
                        {/*    <div style={{backgroundColor:"red"}} onClick={()=>{*/}
                        {/*        console.log(document.querySelectorAll('.counter input')[product.basketItem.indexOf(item)].value)*/}
                        {/*       // setCount(...count,{[product.basketItem.indexOf(item)]: count[product.basketItem.indexOf(item)]+1})*/}
                        {/*        if(document.querySelectorAll('.counter input')[product.basketItem.indexOf(item)].value>1)*/}
                        {/*        document.querySelectorAll('.counter input')[product.basketItem.indexOf(item)].value*/}
                        {/*            = Number(document.querySelectorAll('.counter input')[product.basketItem.indexOf(item)].value)-1*/}

                        {/*        }}>-</div>*/}
                        {/*    <input type="number" step="1" min="1" value={1}/>*/}
                        {/*    <div style={{backgroundColor:"blue",color:"white"}} onClick={()=>*/}
                        {/*        document.querySelectorAll('.counter input')[product.basketItem.indexOf(item)].value*/}
                        {/*            = Number(document.querySelectorAll('.counter input')[product.basketItem.indexOf(item)].value)+1}>+</div>*/}
                        {/*</div>*/}


                        <Counter price = {item.product.price} id = {item.id}/>

                </div>
            )}
<div className='sumPrice'>

        Загальна сума:
    <p>{product.sumPrice} грн</p>
    </div>

        </div>
      );
})

export default Basket;