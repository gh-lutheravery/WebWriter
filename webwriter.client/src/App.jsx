import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
//import { Layout } from './components/Layout';
import { Home } from './Home.jsx';
//import { FetchData } from './components/FetchData';
//import { Payment } from './components/Payment';

import './custom.css'
import { Analytics } from './Analytics.jsx';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Routes>
                    <Route path='/' element={<Home />} />
                    <Route path='/analyze/:url' element={<Analytics />} />
                </Routes>
            </Layout>
        );
    }
}
