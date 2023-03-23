import React from 'react';
import './Warning.css'

const Warning = ({children}) => {
    return (
        <div className='notFullInfo'>{children}</div>
    );
};

export default Warning;