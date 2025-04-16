import React from 'react';
import { WriterappNavbar } from './components/WriterappNavbar.js';
import { PrevWorks } from './components/PrevWorks.js';
import { Genre } from './components/Genre.js';
import { Consistency } from './components/Consistency.js';

export function Analytics() {
    const [tabIndex, setTabIndex] = useState(0);

    return (
        <div>
            <WriterappNavbar />
            <div style={{ width: "100%" }}>
                <h1 style={{ margin: "auto", width: "fit-content" }}>{title} Analytics</h1>
                <h3 style={{ margin: "auto", width: "fit-content" }}>Free Writerapp</h3>
            </div>

            <Tabs selectedIndex={tabIndex} onSelect={(index) => setTabIndex(index)}>
                <TabList>
                    <Tab>Previous Works</Tab>
                    <Tab>Genre</Tab>
                    <Tab>Consistency</Tab>
                </TabList>

                <TabPanel>
                    <PrevWorks urlInput={this.props.match.params.url} />
                </TabPanel>
                <TabPanel>
                    <Genre urlInput={this.props.match.params.url} />
                </TabPanel>
                <TabPanel>
                    <Consistency urlInput={this.props.match.params.url} />
                </TabPanel>
            </Tabs>
        </div>
    );
}
