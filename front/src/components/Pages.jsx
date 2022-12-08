import { observer } from 'mobx-react-lite';
import React from 'react';
import { useContext } from 'react';
import context from 'react-bootstrap/esm/AccordionContext';
import { Context } from '..';


const Pages = observer(() => {
    const {product}=useContext(Context)
    const pages =[]
     const pageCount=Math.ceil(product.totalCount/product.limit)
//console.log(product.totalCount)
 for(let i=0;i<pageCount;i++){
     pages.push(i+1)
 }

    return ( 
        <div className='pages'>
{pages.map(page=>
    <button key={page} style={product.page===page?{backgroundColor:"black"}:{backgroundColor:"blue"}} onClick={(e)=>{
        //e.preventDefault()
        product.setPage(page)}}>{page}</button>)}
        </div>
     );
})
 
export default Pages;