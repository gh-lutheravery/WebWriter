import React, { useEffect, useState } from "react";
import { useNavigate } from 'react-router-dom';

export default function Home() {
    const [viewModel, setViewModel] = useState(null);

    const navigate = useNavigate();

    const handleSubmit = (event) => {
        event.preventDefault();
        navigate('/analyze/' + event.target.elements[0].value);
    };

    useEffect(() => {
        fetch("home", { signal: AbortSignal.timeout(5000) })
            .then((res) => setViewModel(res.data))
            .catch((err) => console.error("Failed to fetch home data", err));
    }, []);

    if (!viewModel) return <div>Loading...</div>;

    return (
        <>
            <div className="text-margin">
                <h2 className="text-danger msg">{viewModel.errorMessage}</h2>
                <h2 className="text-success fade-in msg">{viewModel.successMessage}</h2>
            </div>

            <div className="home-container">
                <div className="home-col">
                    <div className="title-container text-margin" style={{ borderBottom: "5px solid #242424" }}>
                        <h1 className="title-container-text">Analyze stories to grow your audience.</h1>
                    </div>

                    {viewModel.isAuth ? (
                        <div id="search-box-container" className="text-margin">
                            <div style={{ marginBottom: "1rem" }}>
                                <form onSubmit={handleSubmit} autoComplete="off">
                                    <input
                                        id="search-id"
                                        name="searchBar"
                                        type="text"
                                        placeholder="Search A Story"
                                        className="form-control-lg"
                                    />
                                </form>
                            </div>

                        </div>
                    ) : (
                        <div className="login-btn btn text-margin" id="home-btn">
                            <a href={viewModel.redditUrl} id="home-link">Login</a>
                        </div>
                    )}
                </div>
            </div>

            <div id="info-background">
                <div id="info-container" className="text-margin">
                    <div id="feature-container">
                        <h2 style={{ marginBottom: "30px" }}>Features</h2>
                        <ul id="feature-list">
                            <li>See related subreddits to a group of people</li>
                            <li>Observe the websites they mention</li>
                            <li>Access search term analytics</li>
                            <li>Investigate what subreddits mention a search term often</li>
                            <li>and more.</li>
                        </ul>
                    </div>

                    <div id="feature-container">
                        <h2 style={{ marginBottom: "30px" }}>Privacy</h2>
                        <ul id="feature-list">
                            <li><h4>No data from Reddit is stored on this website's servers.</h4></li>
                            <li><h4>No username or password needed if logged in.</h4></li>
                        </ul>
                    </div>
                </div>
            </div>
        </>
    );
}
