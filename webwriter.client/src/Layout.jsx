// Layout.jsx
import React from 'react';
import { Outlet } from 'react-router-dom';
import './layout.css';
import './bootstrap.css';

export const Layout = () => {
    return (
        <>
            <nav className="navbar navbar-expand-md navbar-dark navbar-gr">
                <div className="container container-gr navbar-text-margin">
                    <a className="navbar-brand mr-4 layout-title text-dark">Glancereddit</a>
                    <button className="navbar-toggler dropdown-dark-gr" type="button" data-toggle="collapse" data-target="#navbarToggle" aria-controls="navbarToggle" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarToggle">
                        <div className="navbar-nav mr-auto ml-auto">
                            <div className="nav-item nav-link">
                                {/* Add nav items here if needed */}
                            </div>
                        </div>
                        <div className="navbar-nav">
                            {/* Add user nav or login stuff here */}
                        </div>
                    </div>
                </div>
            </nav>

            <main role="main" className="container container-gr">
                <Outlet /> {/* This is where nested routes render */}
            </main>

            <hr />
            <div className="gr-footer">
                <a className="gr-footer-item" href="https://github.com/gh-lutheravery">Github Page</a>
                <a className="gr-footer-item" href="mailto:lutheravery64@gmail.com">Contact</a>
            </div>
        </>
    );
};
