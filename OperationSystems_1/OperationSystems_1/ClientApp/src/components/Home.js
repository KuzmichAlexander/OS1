import React, {Component} from 'react';
import { fetchDailyData } from '../api';
import { Result } from './Result'
import { ModalWindow } from './ModalWindow'

export class Home extends Component {
  state = {
    items: [],
    delay: 1600,
    requestsCount:0,
    limit:5,
    statusG: false,
    statusY: false,
  };
  

    getRequests = async () =>{
      this._button.disabled = true;
      const timer = setInterval(async () =>{
        this.setState({statusG: true})
        setTimeout(()=>{
          this.setState({statusG: false})
        }, 1300)

        const fetchData = await fetchDailyData();

        this.setState({ items: [...this.state.items, fetchData], statusY: true});
        this.setState({requestsCount:this.state.requestsCount++})
        setTimeout(()=>{
          this.setState({statusY: false})
        }, 1300)
      }, this.state.delay)
      
      //офаем запросы
      setTimeout(()=>{
        clearInterval(timer)
        this.setState({ statusG:false, statusY: false});
      }, this.state.limit * this.state.delay)
    }
    render(){
      return(
      <div className='wrapper'>
      <h1>Асинхронные задачи (TaskQueue)</h1>
      <div className='content'>
        <h3>Задача:</h3>
        <p>Изучение особенностей работы многопоточных приложений</p>
        <h3>Реализация:</h3>
        <p>По нажатию на кнопку на сервер полетят 5 последовательных запросов с переодичностью в 1.6 сек. 
          В теле запроса - случайное дробное число от 0 до 1.</p>
        <input ref={(a)=> this._button = a} type="button" value='Поехали' onClick={() => this.getRequests()}/>
      </div>
      <div className='results'>
        <Result results = {this.state.items}/>  
      </div> 
        <ModalWindow statusG={this.state.statusG} statusY={this.state.statusY}/>
      </div>
      )
    }
    
  
}
