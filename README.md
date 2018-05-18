# CSV File Kata

- Use SOLID principles

## Requirments

Your team has come to you with an urgent requirement. They need to dump Customer objects, as per the
Customer class, to disk in CSV format for a nightly job that imports the data into the CRM system for sales.
You do not need to worry about writing headers as the CRM system has NO need for headers. You do
NOT need to worry about catering for commas in the data. You do NOT need to worry about checking for
existing files or data as the customers will always be dumped to a clean folder. You MUST NOT write to
actual disk, use the IFileSystem interface provided and mock an implementation when building your unit
tests.
