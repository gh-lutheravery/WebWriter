import React from 'react';

import { WriterappNavbar } from './WriterappNavbar.js';

export function AnalyticsView() {
    const [tabIndex, setTabIndex] = useState(0);

    return (
        <div>
            <WriterappNavbar />
            <div style={{ width: "100%" }}>
                <h1 style={{ margin: "auto", width: "fit-content" }}>{title} Analytics</h1>
                <h3 style={{ margin: "auto", width: "fit-content" }}>Free Writerapp</h3>
            </div>
        </div>
    );
}