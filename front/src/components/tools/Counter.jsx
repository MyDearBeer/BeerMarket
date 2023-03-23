import React, {useContext, useState} from 'react';

import {Context} from "../../index";
import {deleteBasketItem} from "../../http/ItemAPI";
import {observer} from "mobx-react-lite";
import {BASKETROUTE, REGROUTE} from "../../utils/consts";
import {useNavigate} from "react-router-dom";



const Counter = observer(({price,id}) => {
    const {product} = useContext(Context)
    const [count,setCount] = useState(1)
    const navigate = useNavigate()

    return (
        <div className='basketright'>
        <div className='counter'>
            <div style={{backgroundColor:"red"}} onClick={()=>{
                if(count>1) {
                    setCount(count - 1)
                    product.setSumPrice(product.sumPrice - price)
                }
            }}>-</div>
            <input type="number" step="1" min="1" value={count}/>
            <div style={{backgroundColor:"blue",color:"white"}} onClick={() =>{
                setCount(count+1)
                product.setSumPrice(product.sumPrice+price)}}>+</div>
        </div>
    <div className='priceDiv'>
        <p>{price*count}</p> грн

    </div>
    <button className="closeBtn" onClick={()=>
        deleteBasketItem(id).then(()=> {
            product.setBasketItem(product.basketItem.filter((item) => item.id !== id))
            product.setSumPrice(product.sumPrice-price*count)


    })}>
        X
    </button>
            </div>
    );
});

export default Counter;