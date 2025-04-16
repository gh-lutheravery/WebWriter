import React from 'react';
import {ListGroup, ListGroupItem, Badge} from 'reactstrap'

export function PrevWorks(tabData) {
    const prevWorks = tabData.tabData;
    console.log(prevWorks);
    // add callback/hook here
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

    return (
        <div>
            <div style={{ marginBottom: "1rem"}}>
                <h2>All other stories done by this author</h2>
            </div>

            <ListGroup>
                {renderPrevWorks(prevWorks)}
            </ListGroup>
        </div>
    );
}