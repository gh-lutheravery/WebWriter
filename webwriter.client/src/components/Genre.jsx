import React from 'react';
import {ListGroup, ListGroupItem, Badge} from 'reactstrap'

export function Genre(tabData) {
    const genreArray = tabData.tabData;
    console.log(genreArray);
    // Updated renderGenres: remove extraneous curly braces and return the result
    const renderGenres = (genres) => {
        return genres.map(genre => {
            if (genre.IsMatch === true) {
                return (
                    <ListGroupItem className="justify-content-between" active key={genre.Name}>
                        {genre.Name}{' '}
                        <Badge>
                            {genre.PopRating}
                        </Badge>
                    </ListGroupItem>
                );
            }
            return (
                <ListGroupItem className="justify-content-between" key={genre.Name}>
                    {genre.Name}{' '}
                    <Badge>
                        {genre.PopRating}
                    </Badge>
                </ListGroupItem>
            );
        });
    };

    return (
        <div>
            <div id="genre-container">  
                <div style={{ marginBottom: "1rem"}}>
                    <h2>How popular are the genres it is in?</h2>
                </div>
                
                <ListGroup> 
                    {renderGenres(genreArray)}
                </ListGroup>
            </div>
        </div>
    );
}