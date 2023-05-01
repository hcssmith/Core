# todo
    - Data Loader (XML)
        From = Table
        .1
            Read from an XML file all rows of a table, loop throw every one in BUsiness process,
            check for Save, create & delete. 
        .2
            Build in a method of filtering
        .3
            Join multiple tables
        .4
            Expand to SQLIte
        .5
            Migration method
    - Engine
        - BusinessProcess
            - DataView
            - Loop (Execute())
                OnStart
                OnEnterRow
                OnLeaveRow
                OnEnd

                Execute
                    Start - prepare
                    OnStart - user method
                    enterrow - retrieve row
                    OnEnterRow - user method
                    leaverow - finalize for saving
                    OnLeaveRow - final user processing
                    Save - If updating enabled, Save
                    End - clear builtin instance variables
                    OnEnd - user method
        - Core
            - DataSources
    - UI?
        Cross platform
        investigate