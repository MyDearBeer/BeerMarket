import React, {useEffect} from 'react';
import './Modal.css'


const Modal = ({active,setActive,children}) => {

    console.log(active)
    return ( 
        <div className={active ? 'myModal active' :'myModal'} onClick={()=>{
            setActive(false)
            document.body.style.overflowY = "scroll"}}>

<div className='myModalContent'onClick={e=>e.stopPropagation()} >

{children}

</div>
        </div>
     );
}
 
export default Modal;