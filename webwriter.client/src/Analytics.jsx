import React from 'react';
import { WriterappNavbar } from './components/WriterappNavbar.jsx';
import { PrevWorks } from './components/PrevWorks.jsx';
import { Genre } from './components/Genre.jsx';
import { Consistency } from './components/Consistency.jsx';
import { useState } from "react";
import { useLocation } from 'react-router-dom';
import { Tabs, TabList, TabPanel, Tab } from 'react-tabs';
import 'react-tabs/style/react-tabs.css';

export function Analytics() {
    const [tabIndex, setTabIndex] = useState(0);

    const { search } = useLocation();
    const params = new URLSearchParams(search);
    const url = params.get('url');

    return (
        <div>
            {/*<WriterappNavbar />*/}
            <div style={{ width: "100%" }}>
                <h1 style={{ margin: "auto", width: "fit-content" }}>Analytics</h1>
                <h3 style={{ margin: "auto", width: "fit-content" }}>Free Writerapp</h3>
            </div>

            <Tabs selectedIndex={tabIndex} onSelect={(index) => setTabIndex(index)}>
                <TabList>
                    <Tab>Genre</Tab>
                    <Tab>Consistency</Tab>
                    <Tab>Previous Works</Tab>
                </TabList>

                <TabPanel>
                    <Genre urlInput={url} />
                </TabPanel>
                <TabPanel>
                    <Consistency urlInput={url} />
                </TabPanel>
                <TabPanel>
                    <PrevWorks urlInput={url} />
                </TabPanel>
            </Tabs>
        </div>
    );
}
