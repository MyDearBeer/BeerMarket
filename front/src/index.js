import React, { createContext } from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';

import ItemMarket from './store/ItemMarket';
import UserMarket from './store/UserMarket';

export const Context=createContext(null)

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
<Context.Provider value={{
  user:new UserMarket(),
  product:new ItemMarket()

 
  }}>
<App />
</Context.Provider>


);


