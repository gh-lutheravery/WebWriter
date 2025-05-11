import React, { Component } from 'react';
import { Routes, Route } from 'react-router-dom';
import Home from './Home.jsx';
import { Analytics } from './Analytics.jsx';
import { Layout } from './Layout.jsx';

import './custom.css';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<Home />} />
                    <Route path="analyze" element={<Analytics />} />
                </Route>
            </Routes>
        );
    }
}
