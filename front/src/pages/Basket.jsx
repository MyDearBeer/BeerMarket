import React from 'react'
import  './Basket.css'

const Basket = () => {
  const item=   {id:1,name:"Львівське 1715",price:20,rating:5,img:"./beerImg/lviv1715.png"}
    return (
        <div className='basket'>
           <div className='basketitem'>
            <div className='basketleft'>
<img src={item.img}></img>
<p>{item.name}</p>
</div>
<div className='basketright'>
<img src={item.img}></img>
<p>{item.name}</p>
</div>
            </div> 
            
        </div>
      );
}
 
export default Basket;