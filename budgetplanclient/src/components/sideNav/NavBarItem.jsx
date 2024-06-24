import PropTypes from "prop-types";
import {useNavigate} from "react-router-dom";

const NavBarItem = ({name, iconName, path}) => {

    const navigate = useNavigate();

    function handleClick(path) {
        navigate(path);
    }

    return (
        <div className={'navbar-item'} onClick={() => handleClick(path)}>
            <span className="material-symbols-outlined">{iconName}</span>
            <a>{name}</a>
        </div>
    );
}

NavBarItem.propTypes = {
    name: PropTypes.string.isRequired,
    iconName: PropTypes.string.isRequired,
    path: PropTypes.string.isRequired
}

export default NavBarItem;