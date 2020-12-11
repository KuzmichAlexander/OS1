import React, {Component} from 'react';
import {fetchDailyData} from '../api';
import {Result} from './Result'
import {ModalWindow} from './ModalWindow'
import {withMobileDialog} from "@material-ui/core";

export class Home extends Component {
    state = {
        items: [],
        delay: 1600,
        requestsCount: 0,
        limit: 5,
        statusG: false,
        statusY: false,
        hash: null
    };

    componentDidMount() {
        this.setState({hash: new Date().getTime()});
    }


    startSendRequests = async () => {
        this._button.disabled = true;
        console.log(this.state)
        this.timer = setInterval(async () => {
            const fetchData = await fetchDailyData(this.state.hash);

            this.setState({items: [...this.state.items, fetchData], statusY: true});
            this.setState({requestsCount: this.state.requestsCount++})

        }, this.state.delay)
    }

    stopSendRequests = () => {
        clearInterval(this.timer)
    }

    render() {
        return (
            <div className='wrapper'>
                <h1>Асинхронные задачи (TaskQueue)</h1>
                <div className='content'>
                    <h3>Задача:</h3>
                    <p>Изучение особенностей работы многопоточных приложений</p>
                    <h3>Реализация:</h3>
                    <p>По нажатию на кнопку на сервер полетят 5 последовательных запросов с переодичностью в 1.6 сек.
                        В теле запроса - случайное дробное число от 0 до 1.</p>
                    <input ref={(a) => this._button = a} type="button" value='Поехали'
                           onClick={() => this.startSendRequests()}/>
                    <input type="button" value='Остановка' onClick={() => this.stopSendRequests()}/>

                </div>
                <div className='results'>
                    <Result results={this.state.items}/>
                </div>
                <ModalWindow statusG={this.state.statusG} statusY={this.state.statusY}/>
            </div>
        )
    }


}
