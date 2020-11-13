import React from 'react';

export const Item = ({result, start, end, startnum, index}) =>{
    console.log(result, start, end, startnum);
    const timeS = new Date(start)
    const timeE = new Date(end)
    return (
        <li>
            <h5>Request № {index+1}</h5>
            <h6>Fetched number: {startnum}; {`\t`} result:{result}</h6>
            <time>Send time: {`${timeS.getHours()}:${timeS.getMinutes()}:${timeS.getSeconds()}\n`}</time>
            <time>Response time: {`${timeE.getHours()}:${timeE.getMinutes()}:${timeE.getSeconds()}`}</time>
        </li>
    )
}