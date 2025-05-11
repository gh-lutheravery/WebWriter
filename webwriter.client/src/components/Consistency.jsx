import React, { useState, useEffect } from 'react';
import {
    AreaChart, CartesianGrid, XAxis,
    YAxis, Tooltip, Legend, Area, ResponsiveContainer
} from 'recharts';

export function Consistency(urlInput) {
    const [consistencyData, setConsistencyData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const url = urlInput.urlInput;

    useEffect(() => {
        const fetchConsistencyData = async () => {
            try {
                const fictionUrl = url;

                if (!fictionUrl) {
                    throw new Error('Fiction URL is required');
                }

                // Fetch data from the API
                const response = await fetch(`Analytics/getConsistencyAnalytics?fictionUrl=${encodeURIComponent(fictionUrl)}`);

                if (!response.ok) {
                    const errorData = await response.json();
                    throw new Error(errorData.error || 'Failed to fetch consistency data');
                }

                const consistencyMap = await response.json();

                // Transform the data for the chart
                const chartData = Object.keys(consistencyMap).map(key => ({
                    name: key,
                    commentLength: consistencyMap[key]
                }));

                console.log(chartData)
                setConsistencyData(chartData);
                setLoading(false);
            } catch (err) {
                console.error('Error fetching consistency data:', err);
                setError(err.message);
                setLoading(false);
            }
        };

        fetchConsistencyData();
    }, []); // Empty dependency array means this effect runs once on mount

    const getIntroOfPage = (titleArray) => {
        return titleArray.join("\n");
    };

    const CustomTooltip = ({ active, payload, label }) => {
        if (active && payload && payload.length) {
            return (
                <div className="custom-tooltip">
                    <p className="label">{`${label} : ${payload[0].value} Chapters`}</p>
                    <p className="intro">{getIntroOfPage(payload[1].value)}</p>
                </div>
            );
        }
        return null;
    };

    if (loading) {
        return <div>Loading consistency data...</div>;
    }

    if (error) {
        return <div className="error-message">Error: {error}</div>;
    }

    return (
        <div id="popularity-container">
            <h2>How consistent has this author been in posting chapters?</h2>
            <div>
                <h2>Consistency Graph</h2>
            </div>

            {consistencyData.length > 0 ? (
                <ResponsiveContainer width="100%" height={450}>
                    <AreaChart width={1030} height={450} data={consistencyData}
                        margin={{ top: 10, right: 30, left: 0, bottom: 0 }}>
                        <defs>
                            <linearGradient id="colorUv" x1="0" y1="0" x2="0" y2="1">
                                <stop offset="5%" stopColor="#8884d8" stopOpacity={0.8} />
                                <stop offset="95%" stopColor="#8884d8" stopOpacity={0} />
                            </linearGradient>
                            <linearGradient id="colorPv" x1="0" y1="0" x2="0" y2="1">
                                <stop offset="5%" stopColor="#82ca9d" stopOpacity={0.8} />
                                <stop offset="95%" stopColor="#82ca9d" stopOpacity={0} />
                            </linearGradient>
                        </defs>
                        <XAxis dataKey="name" />
                        <YAxis />
                        <CartesianGrid strokeDasharray="3 3" />
                        <Tooltip />
                        <Legend />
                        <Area type="monotone" dataKey="commentLength" stroke="#8884d8" fillOpacity={1} fill="url(#colorUv)" />
                    </AreaChart>
                </ResponsiveContainer>
            ) : (
                <div>No consistency data available</div>
            )}
        </div>
    );
}