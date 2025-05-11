import React, { useState, useEffect } from 'react';
import { ListGroup, ListGroupItem, Badge } from 'reactstrap';

export function Genre(urlInput) {
    const url = urlInput.urlInput;
    const [genreArray, setGenreArray] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    console.log("url: " + url)
    useEffect(() => {
        if (!url) return;

        const fetchGenres = async () => {
            try {
                console.log("dsadasd")
                const response = await fetch(`Analytics/getGenres?fictionUrl=${encodeURIComponent(url)}`);
                if (!response.ok) {
                    const err = await response.json();
                    throw new Error(err.error || "Failed to fetch genres.");
                }
                const data = await response.json();
                setGenreArray(data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchGenres();
    }, [url]);

    const renderGenres = (genres) => {
        return genres.map(genre => {
            const { Name, PopRating, IsMatch } = genre;
            return (
                <ListGroupItem className="justify-content-between" active={IsMatch} key={Name}>
                    {Name}{' '}
                    <Badge>
                        {PopRating}
                    </Badge>
                </ListGroupItem>
            );
        });
    };

    return (
        <div id="genre-container">
            <div style={{ marginBottom: "1rem" }}>
                <h2>How popular are the genres it is in?</h2>
            </div>

            {loading && <p>Loading genres...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {!loading && !error && (
                <ListGroup>
                    {renderGenres(genreArray)}
                </ListGroup>
            )}
        </div>
    );
}
