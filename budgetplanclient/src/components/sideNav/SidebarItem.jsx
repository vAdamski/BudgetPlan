import {useNavigate} from "react-router-dom";

function SidebarItem({link, icon, children, className, ...props}) {
    const navigate = useNavigate();

    function handleClick(event) {
        event.preventDefault();
        navigate(link);
    }

    return (
        <li className={`sidebar-item ${className || ''}`}>
            <a className="sidebar-link" onClick={handleClick} {...props}>
                <i className={`lni ${icon}`}></i>
                <span>{children}</span>
            </a>
        </li>
    );
}

export default SidebarItem;