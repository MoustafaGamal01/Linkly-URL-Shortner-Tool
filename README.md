# Linkly
Linkly is a web-based application that allows users to shorten long URLs into concise,
shareable links. This tool is inspired by platforms like Bitly and TinyURL 
but is built from scratch to serve as a learning project for backend web development.

## Features
- Shorten URLs: Convert long URLs into short, easy-to-remember links.
- Custom Shortened Links: Base62 encoding for unique and reliable short codes.
- Real-Time Redirection: Redirect users from the shortened link to the original URL seamlessly.
- Copy Functionality: Copy the shortened URL to your clipboard with one click.
- Responsive Design: Optimized for desktop and mobile devices.

## Technologies Used
- Backend: ASP.NET Core MVC, Entity Framework Core
- Frontend: HTML, CSS, JavaScript
- Database: SQL Server
- Hashing: SHA-256 with Base62 encoding for shortened URL generation