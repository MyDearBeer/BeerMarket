import React,{useState} from 'react'
import CreateItem from '../components/modals/CreateItem';

import Modal from '../components/modals/Modal';
import {createFactories, createTypes, fetchItems} from '../http/ItemAPI';
import './Admin.css'
import CreateType from "../components/modals/CreateType";
import CreateFactory from "../components/modals/CreateFactory";
import DeleteItem from "../components/modals/DeleteItem";
import {observer} from "mobx-react-lite";



const Admin = () => {

  const[modalTypeVisible,setModalTypeVisible] = useState(false)
  const[modalFactoryVisible,setModalFactoryVisible] = useState(false)
  const[modalItemVisible,setModalItemVisible] = useState(false)
    const[modalDelItemVisible,setModalDelItemVisible] = useState(false)




  return (
      <div className='admin'>
        <div className='postbuttons'>
         
         <button className='postbutton' onClick={()=> {
             setModalTypeVisible(true)
              document.body.style.overflowY = "hidden"
         }}>Додати тип товару</button>
         <button className='postbutton' onClick={()=>{
             setModalFactoryVisible(true)
             document.body.style.overflowY = "hidden"
         }}>Додати виробника</button>
         <button className='postbutton' onClick={()=>{
             setModalItemVisible(true)
             document.body.style.overflowY = "hidden"}}>Додати товар</button>

            <button className='deletebutton' onClick={()=> {
                setModalDelItemVisible(true)
                document.body.style.overflowY = "hidden"
            }}>Видалити товар</button>

         <Modal  active={modalTypeVisible} setActive={setModalTypeVisible}>
          <CreateType setActive = {setModalTypeVisible}/>
            </Modal>
            <Modal active={modalFactoryVisible} setActive={setModalFactoryVisible}>

          <CreateFactory setActive={setModalFactoryVisible}/>
            </Modal>

<Modal active={modalItemVisible} setActive={setModalItemVisible}>
            <CreateItem setActive={setModalItemVisible}/>
            </Modal>

            <Modal active={modalDelItemVisible} setActive={setModalDelItemVisible}>
                <DeleteItem setActive={setModalDelItemVisible}/>
            </Modal>
        </div>
        </div>
      );
}
 
export default Admin;