import React from 'react';

export const ModalWindow = ({statusG,statusY}) =>{
    

    return (
        
        <>
            {statusG ? <ModalWindowGreen posRight={'30px'} posTop={'20px'}/> : <ModalWindowGreen posRight={'-400px'}/>}
            {statusY ? <ModalWindowYellow posRight={'30px'} posTop={statusG  ? '120px' : '20px'}/> :  <ModalWindowYellow posRight={'-400px'}/>}
            
        </>
    )
}

const ModalWindowGreen = ({posTop, posRight}) =>{
    return (
        <div style={{right:posRight, top:posTop}} className="MymodalGreen">
            <h3>Запрос отправлен</h3>
        </div>
    )
}
const ModalWindowYellow = ({posTop ,posRight}) =>{
    return (
        <div style={{right:posRight, top:posTop}} className="MymodalYellow">
            <h3>Получен ответ</h3>
        </div>
    )
}