import axios from 'axios';

const url = "https://localhost:44395/api/CeilNumber/"

const getRandNum = () => Math.random().toFixed(1);

export const fetchDailyData = async () => {
    console.log(`${url}${getRandNum()}`);
    const { data } = await axios.get(`${url}${getRandNum()}`);
    return data
  };