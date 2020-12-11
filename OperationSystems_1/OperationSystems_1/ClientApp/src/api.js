import axios from 'axios';

const url = "https://localhost:44395/api/CeilNumber/";

const getRandNum = () => Math.random().toFixed(1);

export const fetchDailyData = async (hash) => {
    const sendObject = {Num: parseFloat(getRandNum()), CurHash: hash.toString()};
    const {data} = await axios.post(`${url}`, sendObject);
    return data;
};