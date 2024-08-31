import {useNavigate} from "react-router-dom";

function SidebarItem({link, icon, children, className, ...props}) {
    const navigate = useNavigate();

    function handleClick(event) {
        event.preventDefault();
        navigate(link);
    }

    return (
        <li className={`sidebar-item ${className || ''}`}>
            <a className="sidebar-link d-flex align-content-center" onClick={handleClick} {...props}>
                <span className={`material-icons-outlined`}>{icon}</span>
                <span className={'mx-2'}>{children}</span>
            </a>
        </li>
    );
}

export default SidebarItem;