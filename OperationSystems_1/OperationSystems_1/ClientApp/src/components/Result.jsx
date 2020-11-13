import React from 'react';
import { Item } from './Item'

export const Result = (props) =>{
    console.log(props.results);
    return(
        <ul>
            {props.results.length ? 
             props.results.map((item, index)=>{
                return <Item key={index} index={index} result={item._result} start={item._TimeStart} end={item._TimeEnd} startnum={item._StartNum}/>
            })
            : "Пока пусто..."} 
        </ul>
       
    )
}