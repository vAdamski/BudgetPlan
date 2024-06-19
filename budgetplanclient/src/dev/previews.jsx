import {ComponentPreview, Previews} from '@react-buddy/ide-toolbox'
import {PaletteTree} from './palette'
import SideNavigationBar from "../components/sideNav/SideNavigationBar.jsx";

const ComponentPreviews = () => {
    return (
        <Previews palette={<PaletteTree/>}>
            <ComponentPreview path="/SideNavigationBar">
                <SideNavigationBar/>
            </ComponentPreview>
        </Previews>
    )
}

export default ComponentPreviews