import {ListGroup, ListGroupItem, Badge} from 'reactstrap'
import React, { useState, useEffect } from 'react';

export function PrevWorks(urlInput) {
    const url = urlInput.urlInput;

    const [prevWorksArray, setprevWorksArray] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    const renderPrevWorks = (works) => 
        works.map(value => (
            <ListGroupItem className="justify-content-between" key={value.id || value.name}>
                {value.name}{' '}
                <Badge>
                    Posts: {value.timeStamp.toString()}
                </Badge>
                <Badge>
                    Total Followers: {value.followers}
                </Badge>
            </ListGroupItem>
        ));

    useEffect(() => {
        if (!url) return; 

        const fetchprevWorkss = async () => {
            try {
                console.log("dsadasd")
                const response = await fetch(`Analytics/getPrevWorks?fictionUrl=${encodeURIComponent(url)}`);
                if (!response.ok) {
                    const err = await response.json();
                    throw new Error(err.error || "Failed to fetch prevWorkss.");
                }
                const data = await response.json();
                setprevWorksArray(data);
            } catch (err) {
                setError(err.message);
            } finally {
                setLoading(false);
            }
        };

        fetchprevWorkss();
    }, [url]);

    return (
        <div>
            <div style={{ marginBottom: "1rem"}}>
                <h2>All other stories done by this author</h2>
            </div>

            {loading && <p>Loading previous works...</p>}
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {!loading && !error && (
                <ListGroup>
                    {renderPrevWorks(prevWorksArray)}
                </ListGroup>
            )}
        </div>
    );
}