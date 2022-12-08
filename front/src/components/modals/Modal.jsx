import React from 'react';
import './Modal.css'


const Modal = ({active,setActive,children}) => {
    return ( 
        <div className={active ? 'myModal active' :'myModal'} onClick={()=>setActive(false)}> 
<div className='myModalContent'onClick={e=>e.stopPropagation()} >
    <div>
{children}
</div>
</div>
        </div>
     );
}
 
export default Modal;